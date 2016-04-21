$(function () {
    var AppRouter = Backbone.Router.extend({
        routes: {
            "": "home",
            "login": "login",
            "files": "showDrives",
            "files(/:drive):(/*path)": "showFilesAndDirs"
        },
        initialize: function () {
            this.loginPageView = new appHostFiles.LoginPageView({ el: $("#content") });
            this.homePageView = new appHostFiles.HomePageView({ el: $("#content") });
            this.hostPageView = new appHostFiles.HostPageView({ el: $("#content") });
            this.drivePageView = new appHostFiles.DrivePageView({ el: $("#content") });
        },
        login: function () {
            this.loginPageView.render();
        },
        home: function () {
            this.homePageView.render();
        },
        showFilesAndDirs: function (drive, path) {
            this.hostPageView.render(drive, path);
        },
        showDrives: function () {
            this.drivePageView.render();
        }
    });
    appHostFiles.App = new AppRouter();
    Backbone.history.start();
})