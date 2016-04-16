function config($stateProvider) {
  $stateProvider
		.state('cards', {
			url: '/cards/:id',
			controller: "FlashController as flashCtrl",
			template: require('./card.html')

		});


}

export default config;
