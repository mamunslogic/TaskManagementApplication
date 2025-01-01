import { useForm } from "react-hook-form";
import { Project } from "../../types/Project";
import useFetch from "../../hooks/UseFetch";
import { useEffect } from "react";
import { formatDate } from "../../Utils";

type Props = {
  projectId: number;
};

const CreateProjectPage = ({ projectId }: Props) => {
  const { data, loading, error } = useFetch<Project>(
    `https://localhost:7069/api/Task/GetProjectById?id=${projectId}`
  );
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
    reset,
  } = useForm<Project>();

  useEffect(() => {
    if (data) {
      const formattedData: Project = {
        ...data,
        dueDate: formatDate(data.dueDate),
        estimatedStartDate: formatDate(data.estimatedStartDate),
        estimatedEndDate: formatDate(data.estimatedEndDate),
      };

      reset(formattedData);
      //reset(data);
    }
  }, [data, reset]);

  const onSubmit = async (data: Project) => {
    console.log(data);
    try {
      const response = await fetch(
        "https://localhost:7069/api/Task/CreateProject",
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(data),
        }
      );

      if (!response.ok) {
        throw new Error("Operation failed.");
      }

      const result = response.json();
      console.log("Success", result);
      reset();
    } catch (error) {
      console.error("Error", error);
    }
  };

  if (loading) return <p>Loading project details...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div>
      <h2 className="text-3xl mb-3">Project Detail</h2>
      {!projectId && (
        <p className="mb-4">Please fill up your project details.</p>
      )}
      <form
        onSubmit={handleSubmit(onSubmit)}
        noValidate
        className="shadow-md rounded px-8 pb-8 mb-4"
      >
        <div className="my-3 text-left">
          <label className="block font-medium text-gray-800 mb-1">
            Project Name
          </label>
          <input
            {...register("name", {
              required: { value: true, message: "Project name required." },
              maxLength: {
                value: 50,
                message: "Maximum 50 characters allowed.",
              },
            })}
            type="text"
            className="border border-gray-400 w-full py-1 px-2  text-violet-500"
          />
          <p className="mt-1 text-sm text-red-500">{errors.name?.message}</p>
        </div>
        <div className="my-3 text-left">
          <label className="block font-medium text-gray-800 mb-1">
            Project Description
          </label>
          <textarea
            {...register("description", {
              maxLength: {
                value: 500,
                message: "Maximum 500 characters allowed.",
              },
            })}
            className="border border-gray-400 w-full py-1 px-2  text-violet-500"
          />
          <p className="mt-1 text-sm text-red-500">
            {errors.description?.message}
          </p>
        </div>
        <div className="my-3 text-left">
          <label className="block font-medium text-gray-800 mb-1">
            Due Date of Your Project
          </label>
          <input
            {...register("dueDate", {
              required: { value: true, message: "Due date required." },
              //   pattern: {
              //     value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/,
              //     message: "Enter a valid email address.",
              //   },
            })}
            type="date"
            className="border border-gray-400 py-1 px-2 w-full  text-violet-500"
          />
          <p className="mt-1 text-sm text-red-500">{errors.dueDate?.message}</p>
        </div>
        <div className="my-3 text-left">
          <label className="block font-medium text-gray-800 mb-1">
            Estimated Start Date of Your Project
          </label>
          <input
            {...register("estimatedStartDate", {})}
            type="date"
            className="border border-gray-400 py-1 px-2 w-full  text-violet-500"
          />
          <p className="mt-1 text-sm text-red-500">
            {errors.estimatedStartDate?.message}
          </p>
        </div>
        <div className="my-3 text-left">
          <label className="block font-medium text-gray-800 mb-1">
            Estimated End Date of Your Project
          </label>
          <input
            {...register("estimatedEndDate", {})}
            type="date"
            className="border border-gray-400 py-1 px-2 w-full text-violet-500"
          />
          <p className="mt-1 text-sm text-red-500">
            {errors.estimatedEndDate?.message}
          </p>
        </div>
        <div className="my-3 text-left">
          <label className="block font-medium text-gray-800 mb-1">
            Estimated ManHours
          </label>
          <input
            {...register("estimatedManHours", {})}
            type="number"
            className="border border-gray-400 py-1 px-2 w-full  text-violet-500"
          />
          <p className="mt-1 text-sm text-red-500">
            {errors.estimatedManHours?.message}
          </p>
        </div>
        <div className="mt-5">
          <button className="w-full bg-purple-500 py-3 text-center text-white">
            Save
          </button>
        </div>
      </form>
    </div>
  );
};

export default CreateProjectPage;
