/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del');
var concat = require('gulp-concat');

var outputLocation = 'dist';

gulp.task('clean', function () {
    del.sync([outputLocation + '/**']);
});

gulp.task('vendor-scripts', function () {
    var vendorSources = {
        jquery: [
                'node_modules/jquery/dist/jquery.min.js',
                'node_modules/angular/angular.min.js',
	            'node_modules/bootstrap/dist/js/bootstrap.min.js',
                'node_modules/toastr/build/toastr.min.js'
        ]
    }

    gulp.src(vendorSources.jquery)
		.pipe(concat('jquery.bundle.min.js'))
		.pipe(gulp.dest(outputLocation + '/scripts/'));
});


gulp.task('default', ['clean', 'vendor-scripts'], function () { });