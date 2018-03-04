var heatMap = {
    heatMap_pageId: 'none',
    heatMap_language: 'en-EN'
}

var heatMap_active = false;

heatMap.Init = function (pageId, language) {
    heatMap.heatMap_pageId = pageId;
    heatMap.heatMap_language = language;

    $('*').click(function (e) {
        if (heatMap_active === false) {
            var uniqueId = checkSiblings(this, 'code[uniqueid]');

            if (uniqueId === undefined) {
                return;
            }

            uniqueId = uniqueId.attr('uniqueid');
            
            heatMap_active = true;

            $.ajax({
                method: 'GET',
                url: '/api/heatmap/heatmap/click',
                data:
                {
                    pageId: heatMap.heatMap_pageId,
                    componentId: uniqueId,
                    language: heatMap.heatMap_language
                }
            })
            .done(function (msg) {
                heatMap_active = false;
            });
        }   
    });
}

function checkSiblings(element, selector) {
    var sblngs = checkPrevious(element, selector);

    if (sblngs === undefined || sblngs.length === 0) {

        var parent = $(element).parent();

        if (parent === undefined || parent.length === 0) {
            return undefined;
        }

        return checkSiblings(parent, selector);
    }

    return sblngs.first();
}

function checkPrevious(element, selector) {
    var curr = $(element);

    if (curr === undefined || curr.length === 0) {
        return undefined;
    }

    if (curr.is(selector)) {
        return curr;
    }

    var prev = curr.prev();
    return checkPrevious(prev, selector);
}