$(function () {
    var AppRouter = Backbone.Router.extend({
        routes: {
            "": "home",
            "login": "login",
            "files(/:drive):(/*path)": "getData"
        },
        initialize: function () {
            this.loginPageView = new appHostFiles.LoginPageView({ el: $("#content") });
            this.homePageView = new appHostFiles.HomePageView({ el: $("#content") });
            this.hostPageView = new appHostFiles.HostPageView({ el: $("#content") });
        },
        login: function () {
            this.loginPageView.render();
        },
        home: function () {
            this.homePageView.render();
        },
        getData: function (drive, path) {
            this.hostPageView.render(drive, path);
        }
    });
    appHostFiles.App = new AppRouter();
    Backbone.history.start();
})