function config($stateProvider) {
  $stateProvider
    .state('subject', {
			url: '/flashcards/createsubject',
			controller: "SubjectController as subjectCtrl",
			template: require('./subject.html')

		});


}

export default config;
