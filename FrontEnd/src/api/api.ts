import axios from "axios";
import { baseUrl } from "../config/config";

export const apiAxios = axios.create({
  baseURL: baseUrl,
  headers: {
    "x-culture": "es-CO",
    "x-version": "V1",
  },
});
