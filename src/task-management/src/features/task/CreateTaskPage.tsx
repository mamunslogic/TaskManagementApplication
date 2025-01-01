const CreateTaskPage = () => {
  return (
    <>
      <div className="flex justify-center my-4">
        <h1 className="text-2xl text-zinc-600 font-bold py-4">Task Detail</h1>
      </div>
      <div className="flex-col justify-center">
        <form>
          <div className="mb2 px-4 py-4">
            <label className="text-zinc-600 font-bold">Name</label>
            <input
              type="text"
              className="border-2 rounded-md w-full px-2 py-2"
              placeholder="John Doe"
            ></input>
          </div>
          <div className="mb2 px-4 py-4">
            <label className="text-zinc-600 font-bold">Email</label>
            <input
              type="email"
              className="border-2 rounded-md w-full px-2 py-2"
              placeholder="john@xyz.com"
            ></input>
          </div>
          <div className="mb2 px-4 py-4">
            <label className="text-zinc-600 font-bold">Date of Birth</label>
            <input
              type="date"
              className="border-2 rounded-md w-full px-2 py-2"
              placeholder="dd/mm/yyyy"
            ></input>
          </div>
          <div className="mb2 px-4 py-4">
            <label className="text-zinc-600 font-bold">Password</label>
            <input
              type="password"
              className="border-2 rounded-md w-full px-2 py-2"
              placeholder="********"
            ></input>
          </div>
          <div className="mb2 px-4 py-4">
            <label className="text-zinc-600 font-bold">Confirm Password</label>
            <input
              type="password"
              className="border-2 rounded-md w-full px-2 py-2"
              placeholder="********"
            ></input>
          </div>
          <div className="mb2 flex justify-center py-8">
            <button className="border-2 rounded-md px-4 py-1 bg-blue-600 text-white font-bold hover:bg-blue-800">
              Save
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default CreateTaskPage;
