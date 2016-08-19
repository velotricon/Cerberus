var AddTranslationController = function ($scope, $http) {
    $scope.Submit = function() {
        var result = {
            Text: $scope.Word,
            LangCode: $scope.ComboValue.Id,
            TranslatedText: $scope.Translation
        };

        $http.post('api/TranslationApi/Add', {
            Text: $scope.Word,
            LangCode: $scope.ComboValue.Id,
            TranslatedText: $scope.Translation
            
        }).error(function (data, status, headers, config) {
            alert('error ' + status);
        }).success(function (data, status, headers, config) {
            alert('success ' + status);
        });
    }
}