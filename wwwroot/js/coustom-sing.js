﻿$(document).ready(function () { "use strict"; $(".toggle-search").on("click", function (e) { $(".app").toggleClass("search-visible"), e.preventDefault() }); $(".content-menu-toggle").on("click", function () { $("body").toggleClass("content-menu-shown") }); !function () { if ($(".horizontal-menu").length) { $(".hide-sidebar-toggle-button").on("click", function (e) { e.preventDefault(), a() }); var e = $(".app-menu li:not(.open) ul"), n = $(".app-menu li.active-page > a"); if ($(window).width() > 1199) null != i && (i.destroy(), i = null); else { var t = document.querySelector(".app-menu"); i = new PerfectScrollbar(t), e.hide() } $(window).resize(function () { if ($(window).width() > 1199 && null != i) i.destroy(), i = null; else { var n = document.querySelector(".app-menu"); i = new PerfectScrollbar(n), e.hide() } }), $(".app-menu li a").on("click", function (e) { var n = $(this).next("ul"), t = $(this).parent("li"), a = $(".app-menu .menu-list > li.open"); if (n.length) return $(window).width() > 1199 ? void e.preventDefault() : (t.hasClass("open") ? (n.slideUp(200), t.removeClass("open"), i.update()) : (a.length && (t.parent().children(".open").children("ul").slideUp(200), t.parent().children(".open").removeClass("open"), i.update()), n.slideDown(200), t.addClass("open"), i.update()), !1) }) } if ($(".app-sidebar").length) { var i; e = $(".accordion-menu li:not(.open) ul"), n = $(".accordion-menu li.active-page > a"), e.hide(), $(".app.menu-hover").length && $(window).width() > 1199 ? (i.destroy(), i = null) : (t = document.querySelector(".app-menu"), i = new PerfectScrollbar(t)), $(window).resize(function () { if ($(".app.menu-hover").length && $(window).width() > 1199 && !i.length) { var e = document.querySelector(".app-menu"); i = new PerfectScrollbar(e) } else i.length && (i.destroy(), i = null) }), $(".accordion-menu li a").on("click", function (e) { var n = $(this).next("ul"), t = $(this).parent("li"), a = $(".accordion-menu > li.open"); if (n.length) return $(".app").hasClass("menu-hover") && $(window).width() > 1199 ? void e.preventDefault() : (t.hasClass("open") ? (n.slideUp(200), t.removeClass("open"), i.update()) : (a.length && (t.parent().children(".open").children("ul").slideUp(200), t.parent().children(".open").removeClass("open"), i.update()), n.slideDown(200), t.addClass("open"), i.update()), !1) }), $(".active-page > ul").length && ($(".app").hasClass("menu-hover") ? $(window).width() < 1199 && n.click() : n.click()), $(".app").hasClass("menu-off-canvas") || ($(window).width() < 1199 && !$(".app").hasClass("sidebar-hidden") ? ($(".hide-app-sidebar-mobile").length || $(".app").append('<div class="hide-app-sidebar-mobile"></div>'), $(".hide-sidebar-toggle-button i").text("last_page")) : $(".hide-sidebar-toggle-button i").text("first_page"), $(window).resize(function () { $(window).width() < 1199 && !$(".app").hasClass("sidebar-hidden") ? ($(".hide-app-sidebar-mobile").length || $(".app").append('<div class="hide-app-sidebar-mobile"></div>'), $(".hide-sidebar-toggle-button i").text("last_page")) : $(".hide-sidebar-toggle-button i").text("first_page") })), $(".hide-sidebar-toggle-button").on("click", function (e) { e.preventDefault(), a() }), $(".hide-app-sidebar-mobile").on("click", function (e) { e.preventDefault(), a() }), $(".menu-off-canvas .hide-sidebar-toggle-button").on("click", function () { return $(".app").toggleClass("menu-off-canvas-show"), $(".app").hasClass("menu-off-canvas-show") ? $(".app-sidebar .logo").addClass("canvas-sidebar-hidden-logo") : setTimeout(function () { $(".app-sidebar .logo").removeClass("canvas-sidebar-hidden-logo") }, 200), !1 }) } function a() { return !$(".app").hasClass("menu-off-canvas") && ($(".app").toggleClass("sidebar-hidden"), $(".app").hasClass("sidebar-hidden") ? (setTimeout(function () { $(".app-sidebar .logo").addClass("hidden-sidebar-logo") }, 200), $(window).width() > 1199 ? $(".hide-sidebar-toggle-button i").text("last_page") : $(".hide-sidebar-toggle-button i").text("first_page")) : ($(".app-sidebar .logo").removeClass("hidden-sidebar-logo"), $(window).width() > 1199 ? $(".hide-sidebar-toggle-button i").text("first_page") : $(".hide-sidebar-toggle-button i").text("last_page")), !1) } }(), $('[data-bs-toggle="popover"]').popover(), $('[data-bs-toggle="tooltip"]').tooltip(), window.addEventListener("load", function () { var e = document.getElementsByClassName("needs-validation"); Array.prototype.filter.call(e, function (e) { e.addEventListener("submit", function (n) { !1 === e.checkValidity() && (n.preventDefault(), n.stopPropagation()), e.classList.add("was-validated") }, !1) }) }, !1), (() => { if ($(".content-menu").length) { const e = document.querySelector(".content-menu"); new PerfectScrollbar(e) } })(), "undefined" != typeof hljs && hljs.initHighlighting() }), $(window).on("load", function () { setTimeout(function () { $("body").addClass("no-loader") }, 1e3) });