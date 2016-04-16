
class SubjectController {
	constructor($http) {
    this._$http = $http;
		// this.id = $stateParams.id;
		this.subject = [];

		this.getData();
	}

	addClass(active) {
		//add class active on click
	}

	addAttribute() {
		element.setAttributeNS(placeholder);
	}



  getData() {
		// this._$http
		// .get(`http://tiy-lr-flashcards.azurewebsites.net/cards/index`)
		// .then((response) => {
		// 	console.log(response);
		// 	this.cards = response.data;
		// });



//TEST DATA -------------------------------------------------------------------
			this.cards = [
			{ name: "Test Name",
				id: 5
			},
			{ name: "Test Name2",
				id: 6
			}
		]
	//-------------------------------------------------------------------

  }

}

export default SubjectController
