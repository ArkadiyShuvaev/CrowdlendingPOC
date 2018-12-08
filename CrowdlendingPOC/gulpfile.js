/// <binding BeforeBuild='build' />
var gulp = require("gulp");
var source = require('vinyl-source-stream');
var babelify = require("babelify")
var browserify = require("browserify");
var rimraf = require("rimraf");

var src = ["ClientApp/index.jsx"];

var paths = {
    webroot: "./wwwroot/",
    node_modules: "./node_modules/",
    clientApp: "./clientApp/"
};
paths.libDest = paths.webroot + "libs/";
paths.jsDest = paths.webroot + "js/";
paths.cssSrc = paths.clientApp + "css/";
paths.cssDest = paths.webroot + "css/";
paths.imagesSrc = paths.clientApp + "images/";
paths.imagesDest = paths.webroot + "images/";
paths.faviconSrc = paths.clientApp + "favicon.ico";
paths.faviconDest = paths.webroot;

gulp.task("build", ["clean:all", "copy:libs", "copy:staticFiles", "copy:css"], function () {

    console.log("Building...");

    return browserify({
        entries: src,
        extensions: ['.jsx'],
        debug: true
    })
        .transform(babelify.configure({
            presets: ["@babel/env", "@babel/preset-react"]
        }))
        .bundle()
        .pipe(source("site.js"))
        .pipe(gulp.dest(paths.jsDest));    
});

gulp.task("copy:libs", ["clean:all"], function () {
    var src = {
        "jquery/dist/": paths.node_modules + "jquery/dist/**",
        "bootstrap/dist/": paths.node_modules + "bootstrap/dist/**",
        "bootbox/": paths.node_modules + "bootbox/bootbox.{min.js,js}"
    };

    for (var destinationDir in src) {
        var destRelativePath = paths.libDest + destinationDir;
        console.log("coping files from the " + src[destinationDir]
            + " folder into the " + destRelativePath + " folder...");
        gulp.src(src[destinationDir]).pipe(gulp.dest(destRelativePath));
    }
});

gulp.task("clean:all", function (cb) {
    console.log("Removing files from the " + paths.webroot + " folder...");
    rimraf(paths.webroot + "*", cb);
});

gulp.task("copy:css", ["clean:all"], function () {

    console.log("coping files from the " + paths.cssSrc
        + " folder into the " + paths.cssDest + " folder...");
    return gulp.src(paths.cssSrc + "*").pipe(gulp.dest(paths.cssDest));
    
});

gulp.task("copy:staticFiles", ["clean:all"], function () {

    console.log("coping files from the " + paths.imagesSrc
        + " folder into the " + paths.imagesDest + " folder...");
    gulp.src(paths.imagesSrc + "*").pipe(gulp.dest(paths.imagesDest));
    console.log("coping " + paths.faviconSrc
        + " file into the " + paths.faviconDest + " ...");
    gulp.src(paths.faviconSrc).pipe(gulp.dest(paths.faviconDest));

});
