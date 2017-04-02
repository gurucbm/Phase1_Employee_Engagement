var gulp			= require('gulp')
,	replace			= require('gulp-replace')

,	libs			= './wwwroot/Framework/'
,	node_modules	= './node_modules/'
;

gulp.task('watch', ['default'], function() {
	gulp.watch('wwwroot/*.ts', ['default']);
});

gulp.task('restore:bootstrap', function() {
	gulp.src([
        node_modules + 'bootstrap/dist/**'
	]).pipe(gulp.dest(libs + 'bootstrap'));
});

gulp.task('restore:ion-rangeslider', function() {
	gulp.src([
        node_modules + 'ion-rangeslider/css/**',
	]).pipe(gulp.dest(libs + 'ion-rangeslider/css'));
	gulp.src([
        node_modules + 'ion-rangeslider/js/**',
	]).pipe(gulp.dest(libs + 'ion-rangeslider/js'));
});

gulp.task('restore:font-awesome', function() {
	gulp.src([
        node_modules + 'font-awesome/css/**',
	]).pipe(gulp.dest(libs + 'font-awesome/css'));
	gulp.src([
        node_modules + 'font-awesome/fonts/**',
	]).pipe(gulp.dest(libs + 'font-awesome/fonts'));
});

gulp.task('restore:aminate.css', function() {
	gulp.src([
        node_modules + 'animate.css/animate.css',
        node_modules + 'animate.css/animate.min.css',
	]).pipe(gulp.dest(libs + 'animate.css/css'));
});

gulp.task('restore:jquery', function() {
	gulp.src([
        node_modules + 'jquery/dist/jquery.min.js'
	]).pipe(gulp.dest(libs));
});

gulp.task('restore:jquery-mousewheel', function() {
	gulp.src([
        node_modules + 'jquery-mousewheel/jquery.mousewheel.js'
	]).pipe(gulp.dest(libs));
});

gulp.task('restore:knockout', function() {
	gulp.src([
		node_modules + 'knockout/build/output/*.js'
	]).pipe(gulp.dest(libs + 'knockout'));

	gulp.src([
		node_modules + 'knockout-mapping/dist/*.*'
	]).pipe(gulp.dest(libs + 'knockout'));
});

gulp.task('restore:nprogress', function () {
	gulp.src([
        node_modules + 'nprogress/nprogress.js'
	,	node_modules + 'nprogress/nprogress.css'
	]).pipe(gulp.dest(libs + 'nprogress'));
});

gulp.task('restore:typeahead.js', function () {
	gulp.src([
        node_modules + 'typeahead.js/dist/*.js'
	])
	.pipe(replace(/"typeahead.js"/g, '"typeahead"'))
	.pipe(gulp.dest(libs + 'typeahead.js'));
});

gulp.task('restore:handlebars', function () {
	gulp.src([
        node_modules + 'handlebars/dist/handlebars.js'
	,	node_modules + 'handlebars/dist/handlebars.min.js'
	]).pipe(gulp.dest(libs + 'handlebars'));
});

gulp.task('restore:requirejs', function () {
	gulp.src([
        node_modules + 'requirejs/*.js'
	,	node_modules + 'requirejs-text/*.js'
	]).pipe(gulp.dest(libs));
});

gulp.task('restore', [
    'restore:bootstrap',
	'restore:font-awesome',
	'restore:ion-rangeslider',
	'restore:aminate.css',
    'restore:jquery',
    'restore:jquery-mousewheel',
    'restore:knockout',
	'restore:nprogress',
	'restore:typeahead.js',
	'restore:handlebars',
    'restore:requirejs'
]);