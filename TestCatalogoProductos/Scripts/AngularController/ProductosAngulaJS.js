var app = angular.module("Productosapp", []);

app.controller("ProductosController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Productos/Add_record',

            data: $scope.Productos

        }).then(function (response) {

            $scope.btntext = "Save";

            $scope.Productos = null;

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

    $http.get("/Productos/Get_data").then(function (d) {

        $scope.record = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display dropDowList

    $http.get("/Productos/setDropDowwTipo").then(function (d) {

        $scope.recordDrop = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display record by id

    $scope.loadrecord = function (id) {

        $http.get("/Productos/Get_databyid?id=" + id).then(function (d) {

            $scope.Productos = d.data[0];
            $scope.Tiposs = d.data[0].Tipos;
        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleterecord = function (id) {

        $http.get("/Productos/delete_record?id=" + id).then(function (d) {

            alert(d.data);

            $http.get("/Productos/Get_data").then(function (d) {

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

            url: '/Productos/update_record',

            data: $scope.Productos

        }).then(function (d) {

            $scope.btntext = "Update";

            $scope.Productos = null;

            alert(d.data);
            //$location.url('/Productos/Show_data');
            window.location = "Show_data";

        }).error(function () {

            alert('Failed');

        });

    };

});