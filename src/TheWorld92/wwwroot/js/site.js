    // site javascript

//function startup() {
//    var ele = document.getElementById("username");
//    ele.innerHTML = "web Develpoer";

//    var main = document.getElementById("main");
//    main.onmouseenter = function () {

//        main.style["background-color"] = "#888;";
//    };
//    main.onmouseleave = function () {

//        main.style["background-color"] = "";

//    };
//};
//startup();


        // site jquery

(function() {
//    var ele = $("#username");
//    ele.text("web Developer");
//    var main = $("#main");
//    main.on("mouseenter", function () {

//        main.style="background-color:black;";
//    });
//    main.on("mouseleave", function () {

//        main.style ="";

//    });

//    var menuitem = $("ul.menu li a");
//    menuitem.on("click", function () {

//        alert("Hello")
//    })


var $sidebarAndWrapper = $("#sidebar, #wrapper");
$("#sidebarToggle").on("click", function(){

    $sidebarAndWrapper.toggleClass("hide-sidebar");
    if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
        $(this).text("Show Sidebar");
    }
    else {

        $(this).text("Hide Sidebar");
    }
});

})();
