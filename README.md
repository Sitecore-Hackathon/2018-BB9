![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# Heat Map module with xConnect

This documentation was made for the BB9 team's (Budapest) entry for the 2018, annual Sitecore Hackathon.
The members of the team are the following:
 - Dániel Bodnár
 - Tamás Tárnok
 - Bence Juhos
 
We worked hard on this module and we had many ideas that, due to the time constraints of the competition, could not make it to the version we present to you now.
We see potential and found many uses of this module so we would like to continue working on it, and implement the features that we could not during the competition.

  

## Summary

 - **Category: xConnect**
 - **Project Name: HeatMap**

We are living in a world where almost every decision, choice or move we make is recorded and stored in a database, on a server, somewhere around the globe. Nowadays most of the experiences we have and the content we see, are tailored to us or the group of individuals we belong to. We want to help creators form these experiences for their customers in the most convenient and user-friendly way possible. We created the xConnect HeatMap to help content editors see the controls that the users mostly interacted with and thus help them make sure that those controls are in the right place at the right time. We provide a clean, easy-to-read overlay in the Experience Editor for every page to check which modules were interacted the most with. This data can help the editors see which modules require a content change or which should be placed elswhere on the page in order to attract more user interaction on said module.

  

## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

- Sitecore 9.0.1

- xConnect

  

## Installation

 1. Install the `sc.package\xConnect-HeatMap-1.2.zip` with the good old Installer Wizard in Sitecore
 2. Copy the **content** of the `<website>\App_Data\HeatMap\xconnnect-configs\` into your xConnect instance
 3. If you want to show anonymous user interactions on the Heat Map then please set `IndexAnonymousContactData` to `true` in the `<xConnectRoot>\App_data\jobs\continuous\IndexWorker\App_data\Config\Sitecore\SearchIndexer\sc.XConnect.IndexerSettings.xml` (recommended for testing)

 5. After the installation is done please do a full site publish
  

## Configuration

**To enable the module add the following snippet to your layout/layouts where you want to use**

```html
@using xConnect.HeatMap.Helpers.HtmlHelperExtensions
<head>
@Html.Sitecore().HeatMapHeader()
</head>
```

> NOTE: this extension method includes all the needed javascripts what the module needs

  

## Usage

After the initial setup the usage of the module will be childsplay. The data collection is fully automated and seamlessly integrated into the HTML structure. After publishing a page, allowing the users to interact with said page, the data collection starts. We collect the data in the xConnect database so that we can store and quickly access large number of interactions with every separate module on the page. The module can be accessed on the Experience Editor. On the View tab at the top, in the Show section there is a new toggle button with the "Enable Heat Map". This is the button that does everythin the editor needs. 

> NOTE: there is a known bug to this all-mighty button doesn't work on
> the first interaction. We couldn't figure out why but you have to
> press the button twice for the first time on every page reload. After
> that it works just fine.

 *Enabling the Heat Map gathers the data from the database and displays it on the Experience Editor on an overlay.*

 ![Heat Map in action](documentation/images/heatmap.PNG?raw=true "Heat Map in action")

 This overlay consist of many bounding boxes around the separate modules and numbers in the corners of these modules. The bounding box colors indicate the popularity of a certain page element. It goes from yellow to red indicating that the module in the box was avoided or clicked a lot of time (respectively). We also included a counter on the top-left part of ever box so you can see exactly how many time was that element interacted with. Note that interaction with the elements in the editor while the Heat Map is enabled is faily limited due to the nature of the overlay, being rendered over the content. If you want to have the full abilty to interact with the content again, you can disable the overlay with the same button that it was brought forth. (View/Show/Enable Heat Map) Enabling and disabling the module multiple times during one page load doesn't load the data from the server every time so the editors don't have to worry about generating too many transactions towards the server while checking the statistics.

## Video

[![Heat Map](https://img.youtube.com/vi/xYqC-A_XUnI/0.jpg)](https://www.youtube.com/watch?v=xYqC-A_XUnI)