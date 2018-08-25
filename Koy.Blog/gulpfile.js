{
    var gulp = require('gulp');

    gulp.task("copyBootstrap", function () {
        gulp.src("node_modules/bootstrap/dist/**").
            pipe(gulp.dest("wwwroot/lib/bootstrap"));
    });
    gulp.task("copyPopper.js", function () {
        gulp.src("node_modules/popper.js/dist/**").
            pipe(gulp.dest("wwwroot/lib/popper.js"));
    });
    gulp.task("copyJQuery", function () {
        gulp.src("node_modules/jquery/dist/**").
            pipe(gulp.dest("wwwroot/lib/jquery"));
    });
}
