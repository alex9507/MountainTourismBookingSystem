// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function resizeIframe(obj) {
    obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px';
    obj.style.width = obj.contentWindow.document.body.schollWidth+ 'px';
}


function bodyOnLoad(obj)
{
    debugger;
    for (var i = 0; i < obj.length; i++)
    {
        var name = obj[i].name,
            chalet_type = obj[i].chalet_type,
            region_type = obj[i].region_type,
            mountain_type = obj[i].mountain_type,
            picture = obj[i].picture;

        //create product cards
        products += "<div class='col-sm-4 product' data-name='" + name
            + "' data-type='" + chalet_type
            + "' data-region='" + region_type
            + "' data-mountain='" + mountain_type
            + "'>< div class='product-inner text-center' > <img src=~/images/'" + picture
            + "<br />Име: " + name
            + "<br />Тип: " + chalet_type
            + "<br />Регион: " + region_type
            + "<br />Планина: " + mountain_type
            + "</div></div > ";
      
        //create dropdown of makes
      //  if (makes.indexOf("<option value='" + make + "'>" + make + "</option>") == -1) {
      //      makes += "<option value='" + make + "'>" + make + "</option>";
      //  }
      //
      //  //create dropdown of models
      //  if (models.indexOf("<option value='" + model + "'>" + model + "</option>") == -1) {
      //      models += "<option value='" + model + "'>" + model + "</option>";
      //  }
      //
      //  //create dropdown of types
      //  if (types.indexOf("<option value='" + type + "'>" + type + "</option>") == -1) {
      //      types += "<option value='" + type + "'>" + type + "</option>";
      //  }
    }
    $("#products").html(products);
   // $(".filter-make").append(makes);
   // $(".filter-model").append(models);
   // $(".filter-type").append(types);
}




var filtersObject = {};

//on filter change
//$(".filter").on("change", function () {
//    var filterName = $(this).data("filter"),
//        filterVal = $(this).val();
//
//    if (filterVal == "") {
//        delete filtersObject[filterName];
//    } else {
//        filtersObject[filterName] = filterVal;
//    }
//
//    var filters = "";
//
//    for (var key in filtersObject) {
//        if (filtersObject.hasOwnProperty(key)) {
//            filters += "[data-" + key + "='" + filtersObject[key] + "']";
//        }
//    }
//
//    if (filters == "") {
//        $(".product").show();
//    } else {
//        $(".product").hide();
//        $(".product").hide().filter(filters).show();
//    }
//});
//
////on search form submit
//$("#search-form").submit(function (e) {
//    e.preventDefault();
//    var query = $("#search-form input").val().toLowerCase();
//
//    $(".product").hide();
//    $(".product").each(function () {
//        var make = $(this).data("make").toLowerCase(),
//            model = $(this).data("model").toLowerCase(),
//            type = $(this).data("type").toLowerCase();
//
//        if (make.indexOf(query) > -1 || model.indexOf(query) > -1 || type.indexOf(query) > -1) {
//            $(this).show();
//        }
//    });
//});