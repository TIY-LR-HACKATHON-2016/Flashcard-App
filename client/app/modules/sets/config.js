function config($stateProvider) {
  $stateProvider
    .state('set', {
			url: '/flashcards/createset/:subject',
			controller: "SetController as setCtrl",
			template: require('./set.html')

		});


}

export default config;
