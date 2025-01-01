import { useState } from "react";
import useFetch from "../../hooks/UseFetch";
import { Project } from "../../types/Project";
import CreateProject from "./CreateProjectPage";

const ProjectListPage = () => {
  const { data, error, loading } = useFetch<Project[]>(
    "https://localhost:7069/api/Task/GetProjects"
  );

  const [selectedProjectId, setSelectedProjectId] = useState<number | null>(
    null
  );

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div className="flex flex-col lg:flex-row w-12/12 lg:w-10/12 px-3 py-10 bg-white text-left rounded-md mx-auto shadow-lg overflow-hidden">
      <div className="w-full lg:w-1/2 px-5">
        <h2 className="text-3xl mb-4 text-left">Project List</h2>
        <ul className="shadow-md rounded px-8 pb-8 mb-4">
          {data?.map((project) => (
            <li
              key={project.id}
              className="bg-gray-100 p-2 mb-4 rounded shadow cursor-pointer"
              onClick={() => setSelectedProjectId(project.id)}
            >
              <p className="text-lg font-semibold">{project.name}</p>
              <p className="text-sm">{project.description}</p>
            </li>
          ))}
        </ul>
      </div>
      <div className="w-full lg:w-1/2 px-5">
        {selectedProjectId && <CreateProject projectId={selectedProjectId} />}
      </div>
    </div>
  );
};

export default ProjectListPage;
