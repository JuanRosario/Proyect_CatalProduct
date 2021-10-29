var app = angular.module("TipoProductoapp", []);

app.controller("TipoProductoController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/TipoProducto/Add_record',

            data: $scope.TipoProducto

        }).then(function (response) {

            $scope.btntext = "Save";

            $scope.TipoProducto = null;

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

    $http.get("/TipoProducto/Get_data").then(function (d) {

        $scope.record = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display record by id

    $scope.loadrecord = function (id) {

        $http.get("/TipoProducto/Get_databyid?id=" + id).then(function (d) {

            $scope.TipoProducto = d.data[0];

        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleterecord = function (id) {

        $http.get("/TipoProducto/delete_record?id=" + id).then(function (d) {

            alert(d.data);

            $http.get("/TipoProducto/Get_data").then(function (d) {

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

            url: '/TipoProducto/update_record',

            data: $scope.TipoProducto

        }).then(function (d) {

            $scope.btntext = "Update";

            $scope.TipoProducto = null;

            alert(d.data);

            window.location = "Show_data";

        }).error(function () {

            alert('Failed');

        });

    };

});