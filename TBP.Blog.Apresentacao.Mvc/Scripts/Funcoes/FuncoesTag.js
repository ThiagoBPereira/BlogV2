//Criar Drop
var autoComplete = {
    //Criar um array
    EstaListagem: [],

    //Split de palavras
    Split: function (palavras) {
        return palavras.split(/,\s*/);
    },

    //Retirar ultima palavra do array de palavras
    ExtrairUltimaPalavra: function (palavras) {
        return this.Split(palavras).pop();
    },

    //Dar get nas tags existentes no banco de dados de acordo com a palavra escrita
    GetNoServidor: function (palavra) {
        $.ajax({
            url: "/Admin/Tag/GetByName",
            type: "GET",
            contentType: "application/json",
            async: false,
            dataType: "json",
            data: { term: this.ExtrairUltimaPalavra(palavra) }
        }).success(function (data) {
            autoComplete.EstaListagem = data.todas;
        });
    },

    //Ordem de como resgatar os dados do servidor
    ResgatarDados: function (palavras) {
        //Extrair a ultima palavra
        var palavra = this.ExtrairUltimaPalavra(palavras);
        this.GetNoServidor(palavra);
        return this.EstaListagem;
    },

    //Montar o controle com autocomplete
    Montar: function (controle) {
        $(controle)
			.bind("keydown", function (event) {
			    if (event.keyCode === $.ui.keyCode.TAB &&
					$(this).autocomplete("instance").menu.active) {
			        event.preventDefault();
			    }
			})
		  .autocomplete({
		      source: function (request, response) {
		          response(autoComplete.SetarPropriedadesDaTag(autoComplete.ResgatarDados(request.term)));
		      },
		      search: function () {
		          // Customização do tamanho mínimo da palavra
		          var term = autoComplete.ExtrairUltimaPalavra(this.value);
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
		          var terms = autoComplete.Split(this.value);

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
    },

    SetarPropriedadesDaTag: function (data) {
        return $.map(data, function (obj) {
            return autoComplete.ParaCadaItem(obj);
        });
    },

    ParaCadaItem: function (obj) {

        var esta = {
            label: obj.Nome,
            value: obj.Nome,
            id: obj.Id
        };
        return esta;

    }
}

//Inserir AutoComplete ao carregar o documento
$(function () {
    autoComplete.Montar("#Tags");
});