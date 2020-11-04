import Axios from "axios";

let baseUrl = window.location.origin.includes('localhost') ? "https://localhost:5001/api/": "/api"
export const api = Axios.create({
  baseURL: baseUrl,
  timeout: 3000
});

export const setBearer = function(bearer) {
  api.defaults.headers.authorization = bearer;
};

export const resetBearer = function() {
  api.defaults.headers.authorization = "";
};
