import { SubmitHandler, useForm } from "react-hook-form";
import registrationImage from "../../assets/images/register.jpg";

interface FormValues {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const UserRegistrationPage = () => {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
    reset,
  } = useForm<FormValues>();

  const onSubmit: SubmitHandler<FormValues> = async (data) => {
    console.log(data);
    const registrationInfo = {
      name: `${data.firstName} ${data.lastName}`,
      email: data.email,
      password: data.password,
    };
    try {
      const response = await fetch(
        "https://localhost:7069/api/User/CreateUser",
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(registrationInfo),
        }
      );

      if (!response.ok) {
        throw new Error("Operation failed.");
      }

      const result = await response.json();
      console.log("Success", result);
      reset();
    } catch (error) {
      console.error("Error:", error);
    }
  };

  const password = watch("password");

  return (
    <div className="flex flex-col lg:flex-row w-12/12 lg:w-10/12 bg-white text-left rounded-md mx-auto shadow-lg overflow-hidden">
      <div
        className="w-full lg:w-1/2 flex flex-col items-center justify-center p-12 bg-cover bg-center bg-no-repeat"
        style={{ backgroundImage: `url(${registrationImage})` }}
      >
        <h1 className="text-white text-3xl mb-3">Welcome</h1>
        <div className="text-white">
          <a href="#" className="text-purple-500 font-semibold">
            MNO
          </a>
          ABC
        </div>
      </div>
      <div className="w-full lg:w-1/2 py-16 px-12">
        <h2 className="text-3xl mb-4">Register</h2>
        <p className="mb-4">
          Create your account. It's free and only take a minute.
        </p>
        <form
          onSubmit={handleSubmit(onSubmit)}
          noValidate
          className="shadow-md rounded px-8 pt-6 pb-8 mb-4"
        >
          <div className="grid grid-cols-2 gap-5">
            <div>
              <input
                {...register("firstName", {
                  required: { value: true, message: "First name required." },
                  maxLength: {
                    value: 20,
                    message: "Maximum 20 characters allowed.",
                  },
                })}
                type="text"
                placeholder="First Name"
                className="border border-gray-400 w-full py-1 px-2"
              />
              <p className="mt-1 text-sm text-red-500">
                {errors.firstName?.message}
              </p>
            </div>
            <div>
              <input
                {...register("lastName", {
                  required: { value: true, message: "Last name required." },
                  maxLength: {
                    value: 20,
                    message: "Maximum 20 characters allowed.",
                  },
                })}
                type="text"
                placeholder="Last Name"
                className="border border-gray-400 w-full py-1 px-2"
              />
              <p className="mt-1 text-sm text-red-500">
                {errors.lastName?.message}
              </p>
            </div>
          </div>
          <div className="mt-5">
            <input
              {...register("email", {
                required: { value: true, message: "Email required." },
                maxLength: {
                  value: 50,
                  message: "Maximum 50 characters allowed.",
                },
                pattern: {
                  value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/,
                  message: "Enter a valid email address.",
                },
              })}
              type="email"
              placeholder="Email"
              className="border border-gray-400 py-1 px-2 w-full"
            />
            <p className="mt-1 text-sm text-red-500">{errors.email?.message}</p>
          </div>
          <div className="mt-5">
            <input
              {...register("password", {
                required: { value: true, message: "Password required." },
                minLength: {
                  value: 6,
                  message: "Minimum 6 characters required.",
                },
                maxLength: {
                  value: 20,
                  message: "Maximum 20 characters allowed.",
                },
                // pattern: {
                //   value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/,
                //   message: "Enter a valid password.",
                // },
              })}
              type="password"
              placeholder="Password"
              className="border border-gray-400 py-1 px-2 w-full"
            />
            <p className="mt-1 text-sm text-red-500">
              {errors.password?.message}
            </p>
          </div>
          <div className="mt-5">
            <input
              {...register("confirmPassword", {
                required: {
                  value: true,
                  message: "Confirm password required.",
                },
                validate: (value) =>
                  value === password || "Passwords do not match.",
              })}
              type="password"
              placeholder="Confirm Password"
              className="border border-gray-400 py-1 px-2 w-full"
            />
            <p className="mt-1 text-sm text-red-500">
              {errors.confirmPassword?.message}
            </p>
          </div>
          <div className="mt-5">
            <input type="checkbox" className="border border-gray-400" />
            <span className="ml-1">
              I accept the
              <a href="#" className="text-purple-500 font-semibold mx-1">
                Terms of Use
              </a>
              &
              <a href="#" className="text-purple-500 font-semibold mx-1">
                Privacy Policy
              </a>
            </span>
          </div>
          <div className="mt-5">
            <button className="w-full bg-purple-500 py-3 text-center text-white">
              Register Now
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default UserRegistrationPage;
