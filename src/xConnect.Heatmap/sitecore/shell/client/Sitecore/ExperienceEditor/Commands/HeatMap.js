var heatMapActivated = false;

define(["sitecore"], function (Sitecore) {
    Sitecore.Commands.HeatMap =
        {
            canExecute: function (context) {
                return true;
            },
            execute: function (context) {
                var elem = window.top.document.getElementsByTagName('html')[0];

                if (context.button.changed.isChecked) {
                    elem.classList.add('heatMap-active');

                    if (!heatMapActivated) {
                        getHeatMap(context);
                    }

                    heatMapActivated = true;
                } else {
                    elem.classList.remove('heatMap-active');
                }
            }
        };
});

function getHeatMap(context) {
    var xmlhttp = new XMLHttpRequest();

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == XMLHttpRequest.DONE) {
            if (xmlhttp.status == 200) {
                var obj = JSON.parse(xmlhttp.response);

                if (obj.length > 0) {
                    for (var i = 0; i < obj.length; i++) {
                        var e = obj[i];
                        var codeElement = window.top.document.getElementById("r_" + e.ComponentId.replace(/-/g, "").toUpperCase());
                        if (codeElement == undefined || codeElement == null) {
                            continue;
                        }

                        var divElement = codeElement.nextElementSibling;
                        if (divElement == undefined || divElement == null) {
                            continue;
                        }

                        var iDiv = document.createElement('div');
                        iDiv.className = 'heatMap-overlay';
                        iDiv.style = "border-color: rgb(255," + (255 - e.NormalizedCount) + ",0)";

                        var countDiv = document.createElement('div');
                        countDiv.innerText = e.Count;
                        countDiv.className = 'click-count';

                        divElement.appendChild(iDiv);
                        divElement.appendChild(countDiv);

                    }
                }
            }
            else {
                console.error("There was an error loading the HeatMap.");
            }
        }
    };

    var hmData = {
        pageId: context.currentContext.itemId,
        language: context.currentContext.language
    };

    xmlhttp.open("GET", "/api/heatmap/heatmap/getclicks?pageId=" + hmData.pageId + "&language=" + hmData.language, true);
    xmlhttp.send();
}