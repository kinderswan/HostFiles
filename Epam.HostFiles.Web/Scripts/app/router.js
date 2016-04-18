$(function () {
    var AppRouter = Backbone.Router.extend({
        routes: {
            "": "home",
            "login": "login"
        },
        initialize: function () {
            this.loginPageView = new appHostFiles.LoginPageView({ el: $("#content") });
            this.homePageView = new appHostFiles.HomePageView({el:$("#content")});
        },
        login: function () {
            this.loginPageView.render();
        },
        home: function () {
            this.homePageView.render();
        }
    });
    appHostFiles.App = new AppRouter();
    Backbone.history.start();
})