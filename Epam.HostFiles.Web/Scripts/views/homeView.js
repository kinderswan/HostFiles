﻿$(function () {
    appHostFiles.HomePageView = Backbone.View.extend({
        events: {
            "click #logout": "logout"
        },
        render: function () {
            appHostFiles.utility.renderTemplate("homePage.htm", $(this.el));
        },
        logout: function () {
            $.ajax({
                url: "api/logout",
                type: "POST"
            })
            .success(function (value) {
                console.dir(value);
            });
            return false;
        }
    });

})