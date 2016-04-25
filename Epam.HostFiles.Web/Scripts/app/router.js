$(function () {
    var AppRouter = Backbone.Router.extend({
        routes: {
            //access
            "login": "login",
            "logout": "home",
            //files and dirs
            "": "showDrives",
            "files": "showDrives",
            "files(/:drive):(/*path)": "showFilesAndDirs",
            //admin
            "admin/users(/:id)": "manageUsers",
            "admin/roles(/:id)": "manageRoles"
        },
        initialize: function () {
            this.loginPageView = new appHostFiles.LoginPageView({ el: $("#content") });
            this.homePageView = new appHostFiles.HomePageView({ el: $("#content") });
            this.hostPageView = new appHostFiles.HostPageView({ el: $("#content") });
            this.drivePageView = new appHostFiles.DrivePageView({ el: $("#content") });
            this.usersPageView = new appHostFiles.UsersPageView({ el: $("#content") });
            this.rolesPageView = new appHostFiles.RolesPageView({ el: $("#content") });
        },

        //users and access functions
        login: function () {
            this.loginPageView.render();
        },
        home: function () {
            this.homePageView.render();
        },
        manageUsers: function(id){
            this.usersPageView.render(id);
        },
        manageRoles: function(id){
            this.rolesPageView.render(id);
        },

        //IO functions
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