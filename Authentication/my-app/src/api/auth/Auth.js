import axios from "axios";
const apiUrl = import.meta.env.VITE_API_URL;

export const Api = axios.create({
    baseURL: `${apiUrl}/api/auth`,
    withCredentials: true
});

export async function signUpUser(user) {
    try {
        const response = await Api.post("/register", user, {
            headers: { "Content-Type": "application/json" },
        });
        console.log("response")
        console.log(response)

    } catch (error) {
        console.error("error  ");
        console.error(error)

    }
}






