function config($stateProvider) {
  $stateProvider
		.state('cards', {
			url: '/cards/:set',
			controller: "FlashController as flashCtrl",
			template: require('./card.html')

		})
}

export default config;
