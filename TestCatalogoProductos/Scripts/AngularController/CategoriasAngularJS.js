var app = angular.module("Categoriasapp", []);

app.controller("CategoriasController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Categorias/Add_record',

            data: $scope.Categorias

        }).then(function (response) {

            $scope.btntext = "Save";

            $scope.Categorias = null;

            alert(response.data);

        }).error(function () {

            alert('Failed');

        });

    };

    app.controller('MainCtrl', function ($scope, $http) {
        $http({
            method: 'GET',
            url: 'api/url-api'
        }).then(function (response) {

        }, function (error) {

        });
    });
    // Display all record

    $http.get("/Categorias/Get_data").then(function (d) {

        $scope.record = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display record by id

    $scope.loadrecord = function (id) {

        $http.get("/Categorias/Get_databyid?id=" + id).then(function (d) {

            $scope.Categorias = d.data[0];

        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleterecord = function (id) {

        $http.get("/Categorias/delete_record?id=" + id).then(function (d) {

            alert(d.data);

            $http.get("/Categorias/Get_data").then(function (d) {

                $scope.record = d.data;

            }, function (error) {

                alert('Failed');

            });

        }, function (error) {

            alert('Failed');

        });

    };
    //update
    $scope.updatedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Categorias/update_record',

            data: $scope.Categorias

        }).then(function (d) {

            $scope.btntext = "Update";

            $scope.Categorias = null;

            alert(d.data);
            
            window.location = "Show_data";

        }).error(function () {

            alert('Failed');

        });

    };

});