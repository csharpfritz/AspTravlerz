var fs = require('fs-extra');

fs.copy('node_modules/bootstrap', 'src/assets/bootstrap', () => {
	console.log("Deployed Bootstrap");
});
fs.copy('node_modules/jquery', 'src/assets/jquery', () => {
	console.log("Deployed jQuery");
});
fs.copy('node_modules/jquery-validation', 'src/assets/jquery-validation', () => {
	console.log("Deployed jQuery-validation");
});
