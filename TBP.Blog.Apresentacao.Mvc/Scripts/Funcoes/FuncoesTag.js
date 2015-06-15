
var repositorio = {
    tags: [],
    getTagByName: function (tagName) {
        getTagByName(tagName);
    }
};


function montarDeAcordo(listagem) {
    return $.map(listagem, function (obj) {
        return {
            label: obj.Nome,
            value: obj.Nome,
            id: obj.IdTag
        };
    });
};

function getTagByName(tag) {
    $.ajax({
        dataType: "json",
        url: "/Admin/Tag/GetByName",
        type: "GET",
        async: false,
        data: { tag: tag }
    }).success(function (data) {
        repositorio.tags = data;
    });
};

function montarControle(controle) {
    $(controle)
        .bind("keydown", function (event) {
            if (event.keyCode === $.ui.keyCode.TAB &&
                $(this).autocomplete("instance").menu.active) {
                event.preventDefault();
            }
        })
        .autocomplete({
            source: function (request, response) {

                var nome = (request.term.split(",")).pop();
                repositorio.getTagByName(nome);
                var cada = montarDeAcordo(repositorio.tags);

                response(cada);
            },
            search: function () {
                // Customização do tamanho mínimo da palavra
                var term = this.value.split(",").pop();
                if (term.length < 2) {
                    return false;
                }
                return true;
            },
            focus: function () {
                // prevent value inserted on focus
                return false;
            },
            select: function (event, ui) {
                var terms = this.value.split(",");

                // remove the current input
                terms.pop();
                // add the selected item
                terms.push(ui.item.value);
                // add placeholder to get the comma-and-space at the end
                terms.push("");
                this.value = terms.join(",");

                return false;
            }
        });
};

$(function () {
    montarControle("#Tags");
});