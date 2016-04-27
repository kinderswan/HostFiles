$(function () {
    var AppRouter = Backbone.Router.extend({
        routes: {

            //user
            "login": "login",
            "logout": "logout",
            "register": "register",
            "index": "index",
            "userProfile": "userProfile",
            "admin": "adminView",

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
            this.logoutPageView = new appHostFiles.LogoutPageView({ el: $("#content") });
            this.hostPageView = new appHostFiles.HostPageView({ el: $("#content") });
            this.drivePageView = new appHostFiles.DrivePageView({ el: $("#content") });
            this.usersPageView = new appHostFiles.UsersPageView({ el: $("#content") });
            this.rolesPageView = new appHostFiles.RolesPageView({ el: $("#content") });
            this.registerPageView = new appHostFiles.RegisterPageView({ el: $("#content") });
            this.indexPageView = new appHostFiles.IndexPageView({ el: $("#content") });
            this.userProfileView = new appHostFiles.UserProfilePageView({ el: $("#content") });
            this.adminPageView = new appHostFiles.AdminPageView({ el: $("#content") });
        },

        //users and access functions
        login: function () {
            this.loginPageView.render();
        },
        logout: function () {
            this.logoutPageView.render();
        },
        index: function(){
            this.indexPageView.render();
        },
        register: function () {
            this.registerPageView.render();
        },
        manageUsers: function (id) {
            var self = this;
            $.ajax({
                url: "api/registeredUser",
                type: "GET",
                success: function (data) {
                    if (data === null) {
                        appHostFiles.App.navigate("index", { trigger: true });
                    }
                    else {
                        self.usersPageView.render(id, data);
                    }
                }
            })
        },
        manageRoles: function (id) {
            var self = this;
            $.ajax({
                url: "api/registeredUser",
                type: "GET",
                success: function (data) {
                    if (data === null) {
                        appHostFiles.App.navigate("index", { trigger: true });
                    }
                    else {
                        self.rolesPageView.render(id, data);
                    }
                }
            });
        },

        //IO functions
        showFilesAndDirs: function (drive, path) {
            var self = this;
            $.ajax({
                url: "api/registeredUser",
                type: "GET",
                success: function (data) {
                    if (data === null) {
                        appHostFiles.App.navigate("index", { trigger: true });
                    }
                    else {
                        self.hostPageView.render(drive, path, data);
                    }
                }
            })

        },
        showDrives: function () {
            var self = this;
            $.ajax({
                url: "api/registeredUser",
                type: "GET",
                success: function (data) {
                    if (data === null) {
                        appHostFiles.App.navigate("index", { trigger: true });
                    }
                    else {
                        self.drivePageView.render(data);
                    }
                }
            })
        },
        userProfile: function () {
            var self = this;
            $.ajax({
                url: "api/registeredUser",
                type: "GET",
                success: function (data) {
                    if (data === null) {
                        appHostFiles.App.navigate("index", { trigger: true });
                    }
                    else {
                        self.userProfileView.render(data);
                    }
                }
            })
        },
        adminView: function () {
            var self = this;
            $.ajax({
                url: "api/registeredUser",
                type: "GET",
                success: function (data) {
                    console.log(data);
                    if (data === null) {
                        appHostFiles.App.navigate("index", { trigger: true });
                    }
                    else {
                        self.adminPageView.render(data);
                    }
                }
            })
        },
    });
    appHostFiles.App = new AppRouter();
    Backbone.history.start();
})