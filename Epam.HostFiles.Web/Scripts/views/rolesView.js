$(function () {
    appHostFiles.RolesPageView = Backbone.View.extend({
        events: {

        },
        render: function (id) {
            appHostFiles.rolesCollection = new appHostFiles.RoleInfoCollection();
            if (id !== null)
            {
                appHostFiles.usersCollection.url = "api/roles/" + id;
            }
            appHostFiles.rolesCollection.fetch({
                success: function (roles) {
                    appHostFiles.utility.renderTemplate("manageRolesPage.html", $("#content"), {
                        roles: roles
                    })
                }
            })
        }

    })
})