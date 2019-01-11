$(function () {


	//Henter doughnut canvas
	var ctx1 = $("#doughnut-chartcanvas-1");

	var ctx2 = $("#doughnut-chartcanvas-2");

	//Data som skal inn i filmstatus
	var statusData = {
		labels: ["Aktiv: ", "Deaktivert: "],
		datasets: [
			{
				data: [activeUsers, inactiveUsers],
				backgroundColor: [
					"rgb(54, 162, 235)",
					"rgb(255, 99, 132)"
				],
				borderColor: [

					"#1D7A46"
				],
				borderWidth: [1, 1]
			}
		]
	};
	//Brukerstatus options
	var statusOption = {
		responsive: false,
		title: {
			display: true,
			position: "top",
			text: "Brukerstatus",
			fontSize: 18,
			fontColor: "#111"
		},
		legend: {
			display: true,
			position: "bottom",
			labels: {
				fontColor: "#111",
				fontSize: 16
			}
		}
	};
	//Filmstatus options
	var movieOption = {
		responsive: false,
		title: {
			display: true,
			position: "top",
			text: "Filmstatus",
			fontSize: 18,
			fontColor: "#111"
		},
		legend: {
			display: true,
			position: "bottom",
			labels: {
				fontColor: "#111",
				fontSize: 16
			}
		}
	};
	var movieData = {
		labels: ["Aktiv: ", "Deaktivert: "],
		datasets: [
			{
				data: [activeMovies, inactiveMovies],
				backgroundColor: [
					"rgb(54, 162, 235)",
					"rgb(255, 99, 132)"
				],
				borderColor: [

					"#1D7A46"
				],
				borderWidth: [1, 1]
			}
		]
	};

	//Lager chart objekt
	var chart1 = new Chart(ctx1, {
		type: "doughnut",
		data: statusData,
		options: statusOption
	});
	var chart2 = new Chart(ctx2, {
		type: "pie",
		data: movieData,
		options: movieOption
	});

});