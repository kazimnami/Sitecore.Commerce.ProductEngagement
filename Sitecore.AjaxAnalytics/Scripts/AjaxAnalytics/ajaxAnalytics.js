AjaxAnalyticsGTM = {
    Consts: {
        ERROR: "Error",
        AnalyticsAPIRoute: "/api/cxa/AjaxAnalytics/RegisterProductGoal"
    },

    GetProductIdFromCanonicalUrl: function() {
        var _this = this;
        var headLinks = document.head.getElementsByTagName("link");
        for (var i = 0; i < headLinks.length; i ++) {
            if (headLinks[i].getAttribute("rel") === "canonical") {
                return href.substring(href.lastIndexOf('/') + 1);
            }
        }
        return _this.Consts.ERROR;
    },

    TriggerProductGoal: function(goalId) {
        var _this = this;
        var productId = _this.GetProductIdFromCanonicalUrl();
        
        var formData = new FormData();
        formData.append("goalId", goalId);
        formData.append("productId", productId);

        var newXHR = new XMLHttpRequest();
        newXHR.open('POST', _this.Consts.AnalyticsAPIRoute);
        newXHR.send(formData);
    }
};

//AjaxAnalyticsGTM.TriggerProductGoal("{EB4C21DB-DBFB-4E4E-83E0-B616AB8C54FF}");