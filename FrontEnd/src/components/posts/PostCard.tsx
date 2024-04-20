import React from "react";
import { Post } from "../../interfaces/Post";
import { getDate } from "../../utils";
import { Link } from "react-router-dom";
import usePosts from "../../hooks/usePosts";
import Swal from "sweetalert2";

interface Props {
  post: Post;
  onDelete: () => void;
}

const PostCard: React.FC<Props> = ({ post, onDelete }) => {

  const { fetchDeletePost } = usePosts();

  const handleDelete = async (postId: string) => {
    const swalResponse = await Swal.fire({
      title: "Are you sure?",
      icon: "warning",
      showConfirmButton: true,
      showCancelButton: true
    });
    
    if (swalResponse.isConfirmed) {
      await fetchDeletePost(postId);
      onDelete();
    }
  }

  return (
    <article className="flex max-w-xl flex-col items-start justify-between">
      <div className="flex items-center gap-x-6 text-xs">
        <a
          href="#"
          className="relative z-10 rounded-full bg-gray-50 px-3 py-1.5 font-medium text-gray-600 hover:bg-gray-100"
        >
          {getDate(post.createdAt)}
        </a>
      </div>
      <div className="group relative">
        <h3 className="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
          <a href="#">
            <span className="absolute inset-0" />
            {post.title}
          </a>
        </h3>
        <p className="mt-5 line-clamp-6 text-sm leading-6 text-gray-600">
          {post.descriptionPost}
        </p>
      </div>
      <div className="relative mt-8 flex items-center gap-x-4">
        <img
          src="https://www.4x4.ec/overlandecuador/wp-content/uploads/2017/06/default-user-icon-8.jpg"
          alt={post.userName}
          className="h-10 w-10 rounded-full bg-gray-50"
        />
        <div className="text-sm leading-6">
          <p className="font-semibold text-gray-900">
            <a href="#">
              <span className="absolute inset-0" />
              {post.userName}
            </a>
          </p>
          <p className="text-gray-600"></p>
        </div>
      </div>
      <div className="mt-10 flex flex-1">
        <Link
            to={`/posts/edit/${ post.id }`}
            className="block rounded-md bg-indigo-600 px-3.5 py-2.5 text-center text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Edit
          </Link>
          <button 
            className="mt-1 block rounded-md bg-red-600 px-3.5 py-2.5 text-center text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
            onClick={() => handleDelete(post.id)}>Delete</button>
      </div>
    </article>
  );
};

export default PostCard;
