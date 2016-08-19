var PersonListController = function ($scope, $http) {

    $scope.PerformRequest = function () {
        $http.get('api/PersonApi').success(function (data, status, headers, config) {
            //alert('success');
            var popup_window = window.open('', '_blank', 'width=300,height=300');
            popup_window.document.open();
            popup_window.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + 'dziendobry' + '</body></html>');
            popup_window.document.close();
        }).error(function (data, status, headers, config) {
            alert('error');
        });
    }
}

PersonListController.$inject = ['$scope', '$http'];