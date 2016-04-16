function config($stateProvider) {
  $stateProvider
    .state('subject', {
			url: '/subject/create',
			controller: "SubjectController as subjectCtrl",
			template: require('./subject.html')

		});


}

export default config;
