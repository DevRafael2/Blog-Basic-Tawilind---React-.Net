import { apiAxios } from "../api/api";

/** Response */
interface UserData {
  userName: string;
  token: string;
  expire: string;
  fullName: string;
  userId: number;
}

const login = async (userName: string, password: string): Promise<UserData> => {
  try {
    const response = await apiAxios.post(`/Api/User/Login`, {
      userName,
      password,
      originIp: "",
      deviceName: "Web",
      operatingSystem: "Windows",
    });
    // ----
    if (response.status !== 200) {
      throw new Error("Invalid email or password");
    }
    // ----
    return response.data.data;
  } catch (error) {
    throw new Error("An error occurred during login. Please try again later.");
  }
};

export { login };
