var menuItems = ['mnWebControls', 'mnAWS'];

function onBodyLoadHandler(controllerName, actionName)
{
    //Set current menu tab
    if (actionName == "About")
        controllerName = "About";

    var currentMenuItem = document.getElementById("mn" + controllerName);
    if (currentMenuItem != null)
        currentMenuItem.className = "selected";

    //Bind onmouse events
    var menuItem = document.getElementById("mnWebControls");
    if ("ontouchstart" in window || "ontouch" in window) {
        for (var c = 0; c < menuItems.length; c++)
            bindIOSEvents(document.getElementById(menuItems[c]));
    }
    else {
        for (var c = 0; c < menuItems.length; c++)
            bindClassicEvents(document.getElementById(menuItems[c]));
    }

}

function bindIOSEvents(menuItem) {
    menuItem.ontouchstart = function () { showSubMenu(this.id); };
    menuItem.touchcancel = function () { hideSubMenu(this.id); };
}

function bindClassicEvents(menuItem) {
    menuItem.onmouseover = function () { showSubMenu(this.id); };
    menuItem.onmouseout = function () { hideSubMenu(this.id); };
}
function showSubMenu(menuId) {
    document.getElementById(menuId + "Items").style.display = "block";
}

function hideSubMenu(menuId) {
    document.getElementById(menuId + "Items").style.display = "none";
}