$("form").submit(function () {
    $(":submit").attr("disabled", "true").html(`<div class="spinner-border text-primary" role="status"><span class="sr-only">Loading...</span></div>`);
});
$("input").keyup(function() {
    $(":submit").removeAttr("disabled", "false").html(`ثبت`);
});
$("input").change(function () {
    $(":submit").removeAttr("disabled", "false").html(`ثبت`);
});
$("select").keyup(function () {
    $(":submit").removeAttr("disabled", "false").html(`ثبت`);
});
$("select").change(function () {
    $(":submit").removeAttr("disabled", "false").html(`ثبت`);
});