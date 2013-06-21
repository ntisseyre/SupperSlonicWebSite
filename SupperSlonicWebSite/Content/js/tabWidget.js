if(!TabWidget) {
	var TabWidget = {}
}

TabWidget.Tab = {
    open: function () {
        //Adjust locations
        document.getElementById('helpspot_widget_mask').style.height = TabWidget.page.theight() + "px";
        document.getElementById('helpspot_widget_mask').style.width = TabWidget.page.twidth() + "px";
        document.getElementById('helpspot_widget_tab_wrapper').style.top = (0.10 * TabWidget.page.height()) + "px";

        //Show mask
        document.getElementById('helpspot_widget_tab_overlay').style.display = 'block';
    },
    close: function () {
        document.getElementById('helpspot_widget_tab_overlay').style.display = 'none';
        //reset frame content
        document.getElementById('helpspot_widget_tab_iframe').src = document.getElementById('helpspot_widget_tab_iframe').src;
    }
}

TabWidget.page=function(){
	return{
		top:function(){return document.body.scrollTop||document.documentElement.scrollTop},
		width:function(){return self.innerWidth||document.documentElement.clientWidth},
		height:function(){return self.innerHeight||document.documentElement.clientHeight},
		theight:function(){
			var d=document, b=d.body, e=d.documentElement;
			return Math.max(Math.max(b.scrollHeight,e.scrollHeight),Math.max(b.clientHeight,e.clientHeight))
		},
		twidth:function(){
			var d=document, b=d.body, e=d.documentElement;
			return Math.max(Math.max(b.scrollWidth,e.scrollWidth),Math.max(b.clientWidth,e.clientWidth))
		}
	}
}();