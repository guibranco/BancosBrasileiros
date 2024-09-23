from setuptools import setup, find_packages

setup(
    name='BancosBrasileiros',
    version='0.1.0',
    description='A package for Brazilian banks information',
    long_description=open('README.md').read(),
    long_description_content_type='text/markdown',
    author='guibranco',
    author_email='author@example.com',
    url='https://github.com/guibranco/BancosBrasileiros',
    packages=find_packages(where='src'),
    package_dir={'': 'src'},
    include_package_data=True,
    classifiers=[
        'Programming Language :: Python :: 3',
        'License :: OSI Approved :: MIT License',
        'Operating System :: OS Independent',
    ],
)