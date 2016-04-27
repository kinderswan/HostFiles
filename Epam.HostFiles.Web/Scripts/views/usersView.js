$(function () {
    appHostFiles.UsersPageView = Backbone.View.extend({
        events: {
            "click #update-user-button": "updateUserProfile"
        },
        render: function (id, user) {
            appHostFiles.utility.renderTemplate("userLi.html", $('#user-nav'), {
                user: user
            });
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

        updateUserProfile: function (e) {
            e.preventDefault();
            console.log(e);
            var userModel = appHostFiles.usersCollection.where({ Login: e.target.form[1].value })
            userModel[0].attributes.UserRole = e.target.form[2].value;
            userModel[0].attributes.UserRoleId = appHostFiles.rolesCollection.where({ Role: e.target.form[2].value })[0].attributes.UserRoleId;

            $.ajax({
                url: "api/users/" + userModel[0].attributes.UserInfoId,
                type: "PUT",
                success: function (data) {
                    console.log(data);
                },
                error: function (data) {
                    console.log(data);
                },
                data: JSON.stringify(userModel[0].attributes),
                cache: false,
                contentType: 'application/json; charset=utf-8',
                processData: false
            });
        }

    })
})