function config($stateProvider) {
  $stateProvider
		.state('cards', {
			url: '/flashcards/createcard/:set',
			controller: "FlashController as flashCtrl",
			template: require('./card.html')

		})
}

export default config;
