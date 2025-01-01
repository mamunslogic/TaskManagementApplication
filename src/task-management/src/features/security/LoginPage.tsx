import { SubmitHandler, useForm } from "react-hook-form";

interface FormValues {
  name: string;
  email: string;
  password: string;
}

const LoginPage = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm<FormValues>();

  const onSubmit: SubmitHandler<FormValues> = (data) => {
    console.log(data);
  };

  return (
    <div className="container flex justify-around mt-4 mb-8">
      <h3 className="text-4xl font-bold">User Registration</h3>
      <form
        onSubmit={handleSubmit(onSubmit)}
        noValidate
        className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4 max-w-md mx-auto"
      >
        <div className="mb-3">
          <label className="block text-sm font-medium text-gray-700">
            Name
          </label>
          <input
            {...register("name", {
              required: { value: true, message: "Name is required." },
              maxLength: {
                value: 20,
                message: "Maximum 20 characters are allowed.",
              },
            })}
            type="text"
            className="mt-1 p-2 block w-full rounded-md border outline-none border-gray-300 focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
          />
          <p className="">{errors.name?.message}</p>
        </div>
        <div className="mb-3">
          <label>Email</label>
          <input
            {...register("email", {
              required: { value: true, message: "Email is required." },
              maxLength: {
                value: 20,
                message: "Maximum 20 characters are allowed.",
              },
            })}
            type="email"
          />
          <p className="">{errors.email?.message}</p>
        </div>
        <div className="mb-3">
          <label>Password</label>
          <input
            {...register("password", {
              required: { value: true, message: "Password is required." },
              minLength: { value: 6, message: "Minimum length 6 is required" },
            })}
            type="password"
          />
          <p className="">{errors.password?.message}</p>
        </div>
        <button
          type="submit"
          className="bg-white text-slate-400 uppercase py-2 px-4 rounded-xl font-semibold cursor-pointer border-2 border-slate-300
          hover:bg-slate-700 hover:text-white transition duration-200 ease-in-out"
        >
          Register
        </button>
      </form>
    </div>
  );
};

export default LoginPage;
