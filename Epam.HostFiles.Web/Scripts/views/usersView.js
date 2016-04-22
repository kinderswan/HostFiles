$(function () {
    appHostFiles.UsersPageView = Backbone.View.extend({
        events: {
            "click #update-user-button": "updateUserProfile"
        },
        render: function (id) {
            appHostFiles.usersCollection = new appHostFiles.UserInfoCollection();
            appHostFiles.rolesCollection = new appHostFiles.RoleInfoCollection();
            if (id !== null) {
                appHostFiles.usersCollection.url = "api/users/" + id;
            }
            appHostFiles.usersCollection.fetch({
                success: function (users) {
                    appHostFiles.rolesCollection.fetch({
                        success: function (roles) {
                            appHostFiles.utility.renderTemplate("manageUsersPage.html", $("#content"), {
                                users: users,
                                roles: roles
                            })
                        }
                    })
                }
            })
        },

        updateUserProfile: function(e)
        {
            e.preventDefault();
            var data = new FormData($("#update-user")[0]);
            console.log($("#update-user"));
            //var oldUserModel = appHostFiles.usersCollection.where({Login: data})
        }

    })
})