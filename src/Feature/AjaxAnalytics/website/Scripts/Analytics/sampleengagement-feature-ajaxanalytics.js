﻿AjaxAnalyticsGTM = {
    Consts: {
        ERROR: "Error",
        RegisterProductGoalAPIRoute: "/api/cxa/AjaxAnalytics/RegisterProductGoal",
        RegisterGoalAPIRoute: "/api/cxa/AjaxAnalytics/RegisterGoal"
    },

    GetProductIdFromCanonicalUrl: function() {
        var _this = this;
        var headLinks = document.head.getElementsByTagName("link");
        for (var i = 0; i < headLinks.length; i ++) {
            if (headLinks[i].getAttribute("rel") === "canonical") {
                return headLinks[i].href.substring(headLinks[i].href.lastIndexOf('/') + 1);
            }
        }
        return _this.Consts.ERROR;
    },

    RegisterProductGoal: function(goalId, productId) {
        var _this = this;
        if (productId || productId === undefined)
            productId = _this.GetProductIdFromCanonicalUrl();
        
        var formData = new FormData();
        formData.append("goalId", goalId);
        formData.append("productId", productId);

        var newXHR = new XMLHttpRequest();
        newXHR.open('POST', _this.Consts.RegisterProductGoalAPIRoute);
        newXHR.send(formData);
    },

    RegisterGoal: function(goalId) {
        var _this = this;
        
        var formData = new FormData();
        formData.append("goalId", goalId);

        var newXHR = new XMLHttpRequest();
        newXHR.open('POST', _this.Consts.RegisterGoalAPIRoute);
        newXHR.send(formData);
    }
};

//AjaxAnalyticsGTM.RegisterProductGoal("{EB4C21DB-DBFB-4E4E-83E0-B616AB8C54FF}");
//AjaxAnalyticsGTM.RegisterProductGoal("{EB4C21DB-DBFB-4E4E-83E0-B616AB8C54FF}", "1234");
//AjaxAnalyticsGTM.RegisterGoal("{EB4C21DB-DBFB-4E4E-83E0-B616AB8C54FF}");