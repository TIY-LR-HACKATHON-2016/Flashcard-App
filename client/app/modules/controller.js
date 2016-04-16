
class FlashController {

	constructor($http, $stateParams) {
    this._$http = $http;
		this.id = $stateParams.id;

		this.getData();
	}

  getData() {
		this._$http
		.get(``)
		.then((response) => {
      console.log(results);

		});
		this._$http
			.get(``)
			.then((response) => {
        console.log(results);

			});
  }

}

export default FlashController
