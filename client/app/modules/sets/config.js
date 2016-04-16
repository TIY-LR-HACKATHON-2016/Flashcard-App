function config($stateProvider) {
  $stateProvider
    .state('set', {
			url: '/set/create',
			controller: "SetController as setCtrl",
			template: require('./set.html')

		});


}

export default config;
