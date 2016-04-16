function config($stateProvider) {
  $stateProvider
		.state('cards', {
			url: '/cards',
			controller: "FlashController as flashCtrl",
			template: require('./card.html')

		})

    .state('subject', {
			url: '/subject/create',
			controller: "FlashController as flashCtrl",
			template: require('./subject.html')

		});


}

export default config;
