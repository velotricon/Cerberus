var GridService = function () {
    var _ModelConstructor = function() {
        this.ViewName = null;
        this.IdentifierColumnName = null;
        this.EditStateName = null;
        this.IndexFrom = null;
        this.IndexTo = null;
        this.PageIndex = 1;
        this.PageSize = 10;
        this.LocaleCode = null;
        this.Columns = new Array();
        this.AdditionalConditions = new Array();
    }

    var _ColumnConstructor = function() {
        this.ColumnName = null;
        this.DataType = null;
    }

    return {
        NewModel: _ModelConstructor,
        NewColumn: _ColumnConstructor
    }
}