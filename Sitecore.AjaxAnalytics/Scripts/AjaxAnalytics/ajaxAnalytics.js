AjaxAnalytics = {
    Consts: {
        ERROR: "Error",
        AnalyticsAPIRoute: "/api/cxa/AjaxAnalytics/RegisterInteraction",
        GoalId: "{79AFA05E-4E87-4339-9302-3DED47B44F08}"
    },

    Setup: function() {
        var _this = this;
        document.getElementById("submitGoal").addEventListener('click', function (event) {      
            event.preventDefault();
            
            var productId = _this.GetProductIdFromCanonicalUrl();
            _this.TriggerGoal(productId, _this.Consts.GoalId);
        
        }, false);
    },

    GetProductIdFromCanonicalUrl: function() {
        var _this = this;
        var headLinks = document.head.getElementsByTagName("link");
        for (var i = 0; i < headLinks.length; i ++) {
            if (headLinks[i].getAttribute("rel") === "canonical") {
                return _this.StripProductIdFromURL(headLinks[i].getAttribute("href"));
            }
        }
        return _this.Consts.ERROR;
    },

    StripProductIdFromURL: function(href) {
        return href.substring(href.lastIndexOf('/') + 1);
    },

    TriggerGoal: function(productId, goalId) {
        var _this = this;
        
        var formData = new FormData();
        formData.append("goalId", goalId);
        formData.append("productId", productId);

        var newXHR = new XMLHttpRequest();
        newXHR.open('POST', _this.Consts.AnalyticsAPIRoute);
        newXHR.send(formData);
    }
};

AjaxAnalytics.Setup();