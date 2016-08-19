//"/Date(1430763733270)/"
//"/Date(1430763808487)/"
//new Date(parseInt("/Date(1430763733270)/".substr(6)))

var JsonDateFilter = function () {
    return function (input) {
        if (input == null) {
            return '';
        }
        var date = new Date(parseInt(input.substr(6)));
        var result_string = "";
        result_string += ('0' + date.getDate()).slice(-2);
        result_string += ".";
        result_string += ('0' + (date.getMonth() + 1)).slice(-2);
        result_string += ".";
        result_string += date.getFullYear().toString();
        return result_string;
    }
}