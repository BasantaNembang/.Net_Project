import React, { useState } from 'react'
import { signUpUser } from '../../api/auth/Auth';

const SignUp = () => {

    const [formData, SetformData] = useState({
        username: "",
        password: "",
    });


    const trackfiled = (e) => {
        const { value, name } = e.target;
        SetformData({ ...formData, [name]: value })
    }

    const submitForm = async(e) => {
        e.preventDefault();

        if (formData.password === "" || formData.password === "") return;
        const response = await signUpUser(formData);
    }


    return (
        <>
            <form method="post">
                <label htmlFor="username">Enter Username</label>
                <input type="text"  name="username" value={formData.username} id="username" onChange={trackfiled} /> <br />
                <label htmlFor="password">Enter Password</label>
                <input type="text" name="password" value={formData.password} id="password" onChange={trackfiled} /> <br />

                <button onClick={submitForm}>Sign-Up</button>
            </form>
        </>
    )
}

export default SignUp;





